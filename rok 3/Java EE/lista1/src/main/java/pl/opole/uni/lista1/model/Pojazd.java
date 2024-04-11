package pl.opole.uni.lista1.model;

import jakarta.persistence.Entity;
import jakarta.persistence.Id;
import jakarta.persistence.Inheritance;
import jakarta.persistence.InheritanceType;

import java.util.Objects;

@Entity
@Inheritance(strategy= InheritanceType.JOINED)
public class Pojazd {
    @Id
    private Integer id;
    private Integer rocznik;
    private Double przebieg;
    private String producent;
    private String kolor;

    public Integer getId() {
        return id;
    }

    public void setId(Integer id) {
        this.id = id;
    }

    public Integer getRocznik() {
        return rocznik;
    }

    public void setRocznik(Integer rocznik) {
        this.rocznik = rocznik;
    }

    public Double getPrzebieg() {
        return przebieg;
    }

    public void setPrzebieg(Double przebieg) {
        this.przebieg = przebieg;
    }

    public String getProducent() {
        return producent;
    }

    public void setProducent(String producent) {
        this.producent = producent;
    }

    public String getKolor() {
        return kolor;
    }

    public void setKolor(String kolor) {
        this.kolor = kolor;
    }

    @Override
    public boolean equals(Object o) {
        if (this == o) return true;
        if (o == null || getClass() != o.getClass()) return false;
        Pojazd pojazd = (Pojazd) o;
        return Objects.equals(id, pojazd.id);
    }

    @Override
    public int hashCode() {
        return Objects.hash(id);
    }
}
