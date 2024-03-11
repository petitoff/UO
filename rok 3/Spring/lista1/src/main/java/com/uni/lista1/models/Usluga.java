package com.uni.lista1.models;

import jakarta.persistence.*;

import java.util.List;

@Entity
public class Usluga {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Integer id;
    private String symbol;
    private String nazwa;
    private Double cena;
    private Boolean dostepnosc;

    @ManyToMany(mappedBy = "uslugi")
    private List<Klient> klienci;

    public Integer getId() {
        return id;
    }

    public void setId(Integer id) {
        this.id = id;
    }

    public String getSymbol() {
        return symbol;
    }

    public void setSymbol(String symbol) {
        this.symbol = symbol;
    }

    public String getNazwa() {
        return nazwa;
    }

    public void setNazwa(String nazwa) {
        this.nazwa = nazwa;
    }

    public Double getCena() {
        return cena;
    }

    public void setCena(Double cena) {
        this.cena = cena;
    }

    public Boolean getDostepnosc() {
        return dostepnosc;
    }

    public void setDostepnosc(Boolean dostepnosc) {
        this.dostepnosc = dostepnosc;
    }


    // Getters and Setters
}
